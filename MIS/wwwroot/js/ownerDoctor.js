const addDoctorButton = document.getElementById("add-doctor");
const addDoctorForm = document.getElementById("popup-msp-doctor");
const submitDocButton = document.getElementById("register-btn");
const cancelButton = document.getElementById("cancel");
const main = document.getElementsByTagName("main")[0];

const addMSPMainButton = document.getElementById("add-msp-button");
const nameOfMsp = document.getElementById("name-msp");
const addressMsp = document.getElementById("adress-msp");
const edrp = document.getElementById("edrp");
const addMspB = document.getElementById("register-msp-btn");
const cancelMspB = document.getElementById("cancel-msp");
const errorMsp = document.getElementById("error-msp");
const mspForm = document.getElementById("add-msp");

const fName = document.getElementById("first-name");
const sName = document.getElementById("second-name");
const mName = document.getElementById("middle-name");
const gender = document.getElementById("gender");
const adress = document.getElementById("adress");
const dateOfBirth = document.getElementById("date-of-birth");
const identifical = document.getElementById("ident-code");

let today = new Date().toISOString().substr(0, 10);

const regName = /^[а-яі-ї]{3,16}$/i;
const regIdent = /^\d{10}$/;
const regEmail = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
const regPhone = /^\+?([3])\)?([8])\)?([0])\)?([0-9]{9})$/;
const regEdrp = /^\d{8}$/;

dateOfBirth.setAttribute("max", today);

addMSPMainButton.addEventListener("click", function(e) {
  e.preventDefault();
  mspForm.style.display = "flex";
});
cancelMspB.addEventListener("click", function(e) {
  e.preventDefault();
  mspForm.style.display = "none";
});
addMspB.addEventListener("click", function(e) {
  e.preventDefault();
  if (showMspError()) {
  }
});

document.getElementById("register-btn").addEventListener("click", function(e) {
  e.preventDefault();
});

addDoctorButton.addEventListener("click", function(e) {
  e.preventDefault();
  addDoctorForm.style.display = "flex";
});

submitDocButton.addEventListener("click", function(e) {
  e.preventDefault();
  if (!showError()) {
  } else {
    addDoctorForm.style.display = "none";
  }
});

cancelButton.addEventListener("click", function(e) {
  e.preventDefault();
  addDoctorForm.style.display = "none";
});

function showMspError() {
  errorMsp.innerText = "";
  errorMsp.style.display = "flex";
  if (nameOfMsp.value === "") {
    errorMsp.innerText += "Введіть назву медичного закладу";
    return false;
  }
  if (addressMsp.value === "") {
    errorMsp.innerText += "Заповніть поле адреси";
    return false;
  }
  if (!regEdrp.test(edrp.value)) {
    errorMsp.innerText += "Код ЄДРПОУ має складатися з 8 чисел";
    return false;
  }
  errorMsp.style.display = "none";
  return true;
}

function showError() {
  error.innerText = "";
  error.style.display = "flex";
  if (
    !regName.test(fName.value) ||
    !regName.test(sName.value) ||
    !regName.test(mName.value)
  ) {
    error.innerText += "Ім'я, прізвище або по-батькові введені не правильно";
    return false;
  }
  if (!regEmail.test(email.value)) {
    error.innerText += "Електронна пошта введена не правильно";
    return false;
  }
  if (!regPhone.test(phone.value)) {
    error.innerText += "Введіть номер телефону у форматі +380XXXXXXXXX";
    return false;
  }
  if (gender.value === "not-chosen") {
    error.innerText += "Стать не вибрана";
    return false;
  }
  if (adress.value === "") {
    error.innerText += "Заповніть поле адреси";
    return false;
  }
  if (!regIdent.test(identifical.value)) {
    error.innerText += "Ідентифікаційний код має складатися з 10 чисел";
    return false;
  }
  if (dateOfBirth.value === "") {
    error.innerText += "Дата народження не вибрана";
    return false;
  }

  error.style.display = "none";
  return true;
}
