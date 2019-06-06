const doctorContainer = document.getElementById("doctor-container");
const doctorSelect = document.getElementById("doctor-name-select");
let doctorChanger = document.getElementById("doctor-name-change");

doctorChanger.addEventListener("input", filter);

fillDoctorSelect();
document.querySelector("#doctor-container").addEventListener("submit", e => {
  e.preventDefault();
  e.target.firstElementChild.setAttribute("name", "Id");
  e.target.submit();
});

function fillDoctorSelect() {
  for (let i = 0; i < doctorContainer.children.length; i++) {
    let doctorName =
      doctorContainer.children[i].children[0].children[2].firstElementChild
        .innerText;
    console.log(doctorName);
    let newOption = document.createElement("option");
    // newOption.innerText = doctorName;
    newOption.setAttribute("value", doctorName);

    doctorSelect.appendChild(newOption);
  }
}

function filter() {
  for (let i = 0; i < doctorContainer.children.length; i++) {
    if (doctorChanger.value === "") {
      doctorContainer.children[i].style.display = "flex";
    } else {
      let doctorName = doctorContainer.children[
        i
      ].children[0].children[2].firstElementChild.innerText.toLowerCase();
      if (doctorName.includes(doctorChanger.value.toLowerCase())) {
        doctorContainer.children[i].style.display = "flex";
      } else doctorContainer.children[i].style.display = "none";
    }
  }
}
//e.preventDefault();
//const data = {
//    EmployeeId: e.target.firstElementChild.value
//};
//console.log(data);
//let http = new Http();
//http.post("CreateDeclaration", data).then(res => { console.log(res); }).catch(err => { console.log(err); });
