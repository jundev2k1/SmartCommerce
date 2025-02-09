const alertBox = {
	status: false,
	check: function (type) {
		const validType = Object.freeze(['success', 'warning', 'danger', 'dialog']);
		if (!validType.includes(type)) {
			console.warn("type must be [success, warning, danger]");
			return false;
		}
		return true;
	},
	button: {
		danger: function (title) {
			const $this = document.querySelector("#alert-box .content .button-group");
			let html = ''
				+ '<button onclick="alertBox.close()" type="button" class="danger">'
				+	title
				+ '</button>';
			$this.innerHTML += html;
		},
		warning: function (title) {
			const $this = document.querySelector("#alert-box .content .button-group");
			let html = `
				<button onclick="alertBox.close()" type="button" class="warning">
					${title}
				</button>`;
			$this.innerHTML += html;
		},
		success: function (title) {
			const $this = document.querySelector("#alert-box .content .button-group");
			let html = `
				<button onclick="alertBox.close()" type="button" class="success">
					${title}
				</button>`;
			$this.innerHTML += html;
		},
		dialog: function (title) {
			const $this = document.querySelector("#alert-box .content .button-group");
			let html = `
				<button onclick="alertBox.close()" type="button" class="dialog">
					${title}
				</button>`;
			$this.innerHTML += html;
		},
	},
	load: function (type, content, subContent, button) {
		if (!this.check(type)) return;

		let html = `
			<div class="overlay"></div>
			<div class="content">
				<div class="show-icon">
					<span></span>
				</div>
				<div class="alert-content">
					<div class="wrapper">
						<h4>${content}</h4>
						<span>${subContent}</span>
					</div>
				</div>
				<div class="button-group">
				</div>
			</div>`;
		const elem = document.createElement("aside");
		elem.id = "alert-box";
		document.body.appendChild(elem);
		document.getElementById("alert-box").innerHTML = html;

		if (type == "success") {
			this.button.success(button);
			this.type(type);
		}
		if (type == "warning") {
			this.button.warning(button);
			this.type(type);
		}
		if (type == "danger") {
			this.button.danger(button);
			this.type(type);
		}
		if (type == "dialog") {
			this.button.dialog(button);
			this.type(type);
		}
	},
	type: function (type) {
		document
			.querySelector("#alert-box .content .show-icon")
			.classList.add(`${type}`);
		const node = document.createElement("em");
		document
			.querySelector("#alert-box .content .show-icon span")
			.appendChild(node);

		let elemIcon = document.querySelector(
			"#alert-box .content .show-icon span em"
		);

		if (type == "success") elemIcon.setAttribute("data-type", "✓");
		if (type == "warning") elemIcon.setAttribute("data-type", "!");
		if (type == "danger") elemIcon.setAttribute("data-type", "✕");
		if (type == "dialog") elemIcon.setAttribute("data-type", "?");
	},
	dialog: function (
		content,
		subContent,
		loadingContent,
		loadingSubContent,
		buttonDialog,
		buttonClose
	) {
		this.load("dialog", content, subContent, buttonDialog);
		this.button.danger(buttonClose);
		document
			.querySelector("#alert-box .content .button-group .dialog")
			.setAttribute(
				"onclick",
				`alertBox.showLoading("${loadingContent}", "${loadingSubContent}")`
			);
	},
	close: function () {
		document.querySelector("aside#alert-box").remove();
	},
	showLoading: function (loadingContent, loadingSubContent) {
		document.querySelector("#alert-box .content .show-icon span em").remove();
		document
			.querySelector("#alert-box .content .show-icon span")
			.classList.add("loader");
		document.querySelector(
			"#alert-box .content .alert-content h4"
		).textContent = loadingContent;
		document.querySelector(
			"#alert-box .content .alert-content span"
		).textContent = loadingSubContent;

		const btnGroup = document.querySelectorAll(
			"#alert-box .content .button-group button"
		);
		btnGroup.forEach((item, index) => {
			item.remove();
		});

		this.status = true;
		let count = 0;
		let exitLoading = setInterval(() => {
			count++;
			if (count == 5) {
				clearInterval(exitLoading);
				this.close();
			}
			if (count == 5) this.close();
		}, 2000);
	},
	hideLoading: function (type, content, subContent, button) {
		let count = 0;
		let checkShow = setInterval(() => {
			if (this.status == true) {
				this.close();
				clearInterval(checkShow);
				this.load(type, content, subContent, button);
			}
			if (count == 30000) this.close();
			count++;
		}, 2000);
	},
};
