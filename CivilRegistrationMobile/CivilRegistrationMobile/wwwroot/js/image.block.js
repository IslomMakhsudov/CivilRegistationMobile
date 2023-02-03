function showPreview(element) {

    if (element.target.files.length > 0) {
        let parent = element.target.closest(".form-input");
        let file = parent.querySelector(".file-input");

        if (element.target.files[0].size < 10000000) {
            
            let src = URL.createObjectURL(element.target.files[0]);
            let wrapper = parent.querySelector(".inner");
            let preview = parent.querySelector(".file-ip-preview");

            wrapper.style.display = "none";
            preview.src = src;
            preview.style.display = "block";

        } else {
            let alert = document.querySelector(".alert");
            if (alert.classList.contains("d-none")) {
                alert.classList.remove("d-none");
            }
            file.value = "";
        }

  }
}

function clear(event) {
    let parent = event.target.closest(".form-input");
    let file = parent.querySelector(".file-input")
    let wrapper = parent.querySelector(".inner");
    let preview = parent.querySelector(".file-ip-preview");
    preview.style.display = "none";
    wrapper.style.display = "block";
    file.value = "";
}

function closeAlert() {
    let alert = document.querySelector(".alert");
    alert.classList.add("d-none");
}

function deleteImage(element) {
    let parent = element.closest(".form-input");
    let file = parent.querySelector(".file-input");
    let wrapper = parent.querySelector(".inner");
    let preview = parent.querySelector(".file-ip-preview");

    preview.style.display = "none";
    wrapper.style.display = "block";
    file.value = "";
}

