const UploadMultipleImage = {
    options: {
        maximumSize: 10000000,
        accept: ['jpg', 'jpeg', 'png'],
    },
    rootElement: null,
    fileInput: null,
    selectInput: null,
    dropArea: null,
    subImageArea: null,
    selectImages: [],
    handleDropArea() {
        this.dropArea.addEventListener('dragstart', (event) => {
            event.preventDefault();
            if (!this.dropArea.classList.contains('dragging')) this.dropArea.classList.add('dragging');
        });
        this.dropArea.addEventListener('dragover', (event) => {
            event.preventDefault();
            if (!this.dropArea.classList.contains('dragging')) this.dropArea.classList.add('dragging');
        });
        this.dropArea.addEventListener('dragleave', (event) => {
            if (this.dropArea.classList.contains('dragging')) this.dropArea.classList.remove('dragging');
        });
        this.dropArea.addEventListener('drop', (event) => {
            event.preventDefault();
            if (this.dropArea.classList.contains('dragging')) this.dropArea.classList.remove('dragging');

            const input = event.dataTransfer.files;
            const validFiles = this.validateFiles([...input]);
            const dataTransfer = new DataTransfer();
            for (let index = 0; index < this.fileInput.files.length; index++) {
                dataTransfer.items.add(this.fileInput.files[index]);
            }
            validFiles.forEach((file) => {
                dataTransfer.items.add(file);
            });
            this.fileInput.files = dataTransfer.files;
            this.loadImages();
        });
    },
    validateFiles(files = []) {
        const validFiles = [];
        files?.forEach((file) => {
            const fileExtension = file.name.split('.').pop().toLowerCase();
            if (!this.options.accept.includes(fileExtension)) {
                toastr.error(`${file.name} chứa đuôi file không hợp lệ.`);
                return;
            }
            if (this.options.maximumSize < file.size) {
                toastr.error(`${file.name} nặng quá 10MB.`);
                return;
            }

            validFiles.push(file);
        });

        return validFiles;
    },
    renderFiles() {
        const reader = new FileReader();
        this.fileInput.files.forEach((file) => {
            reader.readAsDataURL(file);
        });
        reader.onload = function (event) {
            this.loadImages(event);
        };
    },
    onPreview(target) {

    },
    getPreviewItems() {

    },
    setEvent() {
        this.fileInput.addEventListener('change', this.loadImages);
        this.handleDropArea();
    },
    loadImages({ data, imageHead, isInit = false }) {
        if (isInit) {
            return;
        }
    },
    canExecute() {
        const result = this.rootElement && this.fileInput && this.selectInput && this.dropArea && this.subImageArea;
        return result;
    },
    init() {
        const targetElement = document.querySelector('.upload-image');
        if (!targetElement) return;

        this.rootElement = targetElement;
        this.selectInput = targetElement.querySelector('#hfSelectImageInput');
        this.fileInput = targetElement.querySelector('#fileUploadInput');
        this.dropArea = targetElement.querySelector('.drop-area');
        this.subImageArea = targetElement.querySelector('.subImage');
        if (!this.canExecute()) {
            console.error(`#${targetElement.id} Not enough element to execute`);
            return;
        }

        const initialData = targetElement.querySelector('#hfUploadDataInit');
        if (initialData && (initialData.value !== '')) {
            this.loadImages({ data: initialData.value, imageHead: initialData.dataset['uploadPath'] });
        }

        this.setEvent();
    }
};
