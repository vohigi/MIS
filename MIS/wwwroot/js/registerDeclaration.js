const fName = document.getElementById("first-name");
const sName = document.getElementById("second-name");
const mName = document.getElementById("middle-name");
const gender = document.getElementById("gender");
const adress = document.getElementById("adress");
const dateOfBirth = document.getElementById("date-of-birth");
const identifical = document.getElementById("ident-code");

const successForm = document.getElementById("success-form");
const okButton = document.getElementById("submit-declaration");

let today = new Date().toISOString().substr(0, 10);

const error = document.getElementById("error");

//all regular expressions for validation
const regName = /^[а-яі-ї]{3,16}$/i;
const regIdent = /^\d{10}$/;

dateOfBirth.setAttribute("max", today); //setting max date as today

//calling validate function to send ajax if everything is filled
document.getElementById("register-btn").addEventListener("click", function(e) {
  e.preventDefault();
  validate();
});
//onclick event which calls when everyting is correctly filled
okButton.addEventListener("click", function() {});

//function for fields validation
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

function validate() {
  if (showError()) {
    const data = {
      patient: {
        FirstName: fName.value,
        MiddleName: mName.value,
        LastName: sName.value,
        Phone: phone.value,
        Email: email.value,
        Address: adress.value,
        Gender: gender.value,
        BirthDate: dateOfBirth.value,
        TaxID: identifical.value
      },
      Password: password.value,
      CreateDate: today,
      msp: {},
      employee: {}
    };
    sendData(data); //calling ajax
  }
}
function sendData(data) {
  let http = new Http();
  http
    .post("CreateDeclaration1", data)
    .then(res => {
      console.log(res);
      if (JSON.parse(res).value === "ok") {
        successForm.style.display = "flex"; //showing hidden form which tells that validation is successful
      }
      // error.innerHTML = res;
    })
    .catch(error => {
      alert("Suka ne rabotaet blyat nahoy");
    });
}
