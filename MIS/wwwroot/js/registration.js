const email = document.getElementById("email");
const password = document.getElementById("password");
const passwordRepeat = document.getElementById("second-password");
const phone = document.getElementById("phone");
const form = document.getElementById("form");
//const userId = document.getElementById("user-id");

const successForm = document.getElementById("success-form");
const okButton = document.getElementById("submit-declaration");

const error = document.getElementById("error");

//all regular expressions for validation
const regLog = /^[a-zA-Z0-9]{3,16}$/i;
const regEmail = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
const regPass = /^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z])[a-zA-Z0-9!/^_*]{8,16}$/;
const regPhone = /^\+?([3])\)?([8])\)?([0])\)?([0-9]{9})$/;

//calling validate function to send ajax if everything is filled
document.getElementById("register-btn").addEventListener("click", function(e) {
  e.preventDefault();
  validate();
});
//onclick event which calls when everyting is correctly filled
okButton.addEventListener("click", function() {
  window.location = "/";
});

//function for fields validation
function showError() {
  error.innerText = "";
  error.style.display = "flex";
  // if (!regLog.test(userId.value)) {
  //   error.innerText +=
  //     "Логін має складатися з латинських літер та \n" +
  //     "чисел та входити в проміжок від 3 до 16 символів";
  //   return false;
  // }
  if (!regEmail.test(email.value)) {
    error.innerText += "Електронна пошта введена не правильно";
    return false;
  }
  if (!regPhone.test(phone.value)) {
    error.innerText += "Введіть номер телефону у форматі +380XXXXXXXXX";
    return false;
  }
  if (password.value === passwordRepeat.value) {
    if (!regPass.test(password.value)) {
      error.innerText +=
        "Пароль має містити числа, літери верхнього та нижнього \n" +
        "регістру та входити в проміжок від 8 до 16 символів";
      return false;
    }
  } else {
    error.innerText += "Паролі не збігаються";
    return false;
  }

  error.style.display = "none";
  return true;
}

function validate() {
  if (showError()) {
    const data = {
      Email: email.value,
      Password: password.value,
      ConfirmPassword: passwordRepeat.value,
      PhoneNumber: phone.value
    };
    form.submit();
    //calling ajax
  }
}
function sendData(data) {
  let http = new Http();
  http
    .post("Account/Register", data)
    .then(res => {
      console.log(res);
      if (JSON.parse(res).value === "ok") {
        successForm.style.display = "flex"; //showing hidden form which tells that validation is successful
      }
      // error.innerHTML = res;
    })
    .catch(error => {
      alert(error);
    });
}
