const main = document.getElementsByTagName("main")[0];

const addMSPMainButton = document.getElementById("add-msp-button");
const nameOfMsp = document.getElementById("name-msp");
const addressMsp = document.getElementById("adress-msp");
const edrp = document.getElementById("edrp");
const addMspB = document.getElementById("register-msp-btn");
const cancelMspB = document.getElementById("cancel-msp");
const errorMsp = document.getElementById("error-msp");
const mspForm = document.getElementById("add-msp");

const regName = /^[а-яі-ї]{3,16}$/i;
const regIdent = /^\d{10}$/;
const regEmail = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
const regPhone = /^\+?([3])\)?([8])\)?([0])\)?([0-9]{9})$/;
const regEdrp = /^\d{8}$/;

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
    document.getElementById("add-msp-form").submit();
  }
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
