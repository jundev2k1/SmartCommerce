// Copyright (c) 2024 - Jun Dev. All rights reserved

const fs = require('fs');
const path = require('path');

const directory = path.join(__dirname, 'wwwroot/js');

function addJSExtension(file) {
	const content = fs.readFileSync(file, 'utf8');
	const updatedContent = content.replace(/(import.*?from\s+['"])(\..*?)(['"])/g, '$1$2.js$3');
	fs.writeFileSync(file, updatedContent, 'utf8');
}

function processDirectory(directory) {
	fs.readdirSync(directory).forEach(file => {
		const fullPath = path.join(directory, file);
		if (fs.lstatSync(fullPath).isDirectory()) {
			processDirectory(fullPath);
		} else if (file.endsWith('.js')) {
			addJSExtension(fullPath);
		}
	});
}

processDirectory(directory);
