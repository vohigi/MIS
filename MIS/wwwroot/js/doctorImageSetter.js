// console.log(doctorContainer);
loadImages();
function loadImages() {
  // console.log(doctorContainer.children);
  for (
    let i = 0;
    i < document.getElementById("doctor-container").children.length;
    i++
  ) {
    // console.log(doctorContainer.children[i]);
    const form = document.getElementById("doctor-container").children[i]
      .children[0];
    let employeeId = form.children[0].getAttribute("value");
    form.children[1].setAttribute("src", "../images/doctors/" + 1 + ".jpg");
    // console.log(form.children[1]);
  }
}
