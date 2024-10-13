const fs = require('fs');
const path = require('path');

// Thư mục chứa file JS đã biên dịch từ TS
const rootDir = path.join(__dirname, 'wwwroot/js');

// Hàm thêm đuôi '.js' vào import/export
function addJsExtension(content) {
	return content.replace(/(import\s.*?['"])([^'"]+)(['"])/g, (match, p1, p2, p3) => {
		if (!p2.endsWith('.js') && (p2.startsWith('./') || p2.startsWith('../'))) {
			return `${p1}${p2}.js${p3}`;
		}
		return match;
	}).replace(/(export\s.*?from\s['"])([^'"]+)(['"])/g, (match, p1, p2, p3) => {
		if (!p2.endsWith('.js') && (p2.startsWith('./') || p2.startsWith('../'))) {
			return `${p1}${p2}.js${p3}`;
		}
		return match;
	});
}

// Hàm xử lý một file cụ thể
function processFile(filePath) {
	fs.readFile(filePath, 'utf8', (err, content) => {
		if (err) {
			console.error(`Error reading file ${filePath}:`, err);
			return;
		}

		// Thêm đuôi .js vào các hàm import/export
		const modifiedContent = addJsExtension(content);

		// Ghi lại nội dung đã chỉnh sửa vào file
		fs.writeFile(filePath, modifiedContent, 'utf8', (err) => {
			if (err) {
				console.error(`Error writing file ${filePath}:`, err);
			} else {
				console.log(`Updated: ${filePath}`);
			}
		});
	});
}

// Hàm thu thập tất cả các file .js trong thư mục (bao gồm cả thư mục con)
function getAllJsFiles(directory, jsFiles = []) {
	const files = fs.readdirSync(directory, { withFileTypes: true });

	files.forEach((file) => {
		const filePath = path.join(directory, file.name);
		if (file.isDirectory()) {
			// Nếu là thư mục, duyệt đệ quy
			getAllJsFiles(filePath, jsFiles);
		} else if (file.isFile() && file.name.endsWith('.js')) {
			// Nếu là file .js, thêm vào danh sách
			jsFiles.push(filePath);
		}
	});

	return jsFiles;
}

// Hàm chính: Lấy tất cả các file .js và sau đó xử lý chúng
function main() {
	const jsFiles = getAllJsFiles(rootDir);
	console.log(`Found ${jsFiles.length} .js files.`);

	// Thực hiện xử lý từng file
	jsFiles.forEach(processFile);
}

// Gọi hàm chính để bắt đầu
main();