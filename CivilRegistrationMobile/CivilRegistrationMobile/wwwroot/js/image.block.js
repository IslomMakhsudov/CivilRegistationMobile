function showPreview(event) {
  if (event.target.files.length > 0) {
    let src = URL.createObjectURL(event.target.files[0]);
    let parent = event.target.closest(".form-input");
    let deleteBtn = parent.querySelectorAll(".delete");;
    let file = parent.querySelector(".file-input")
    let wrapper = parent.querySelector(".inner");
    let preview = parent.querySelector(".file-ip-preview");
    wrapper.style.display = "none";
    preview.src = src;
    preview.style.display = "block";

    deleteBtn.forEach((e) => {
      e.addEventListener("click", () => {
        preview.style.display = "none";
        wrapper.style.display = "block";
        file.value = "";
      });
    });
  }
}

