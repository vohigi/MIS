let dateOne = document.getElementById("data1");
let dateTwo = document.getElementById("data2");
let dateThree = document.getElementById("data3");
let dateFour = document.getElementById("data4");
let dateFive = document.getElementById("data5");
let dateSix = document.getElementById("data6");
let dateSeven = document.getElementById("data7");

let table = document.getElementById("app-time-choose-body");

table.addEventListener("click", e => {
  console.log(e);
});

setDates();
function setDates() {
  let today = new Date();
  switch (today.getDay()) {
    case 0:
      dateFour.innerText =
        "Неділя, " + today.getDate() + "/" + today.getMonth();
      today.setDate(today.getDate() + 1);
      dateTwo.innerText =
        "Понеділок, " + today.getDate() + "/" + today.getMonth();
      today.setDate(today.getDate() + 1);
      dateThree.innerText =
        "Вівторок, " + today.getDate() + "/" + today.getMonth();
      today.setDate(today.getDate() + 1);
      dateFour.innerText =
        "Середа, " + today.getDate() + "/" + today.getMonth();
      today.setDate(today.getDate() + 1);
      dateFive.innerText =
        "Четвер, " + today.getDate() + "/" + today.getMonth();
      today.setDate(today.getDate() + 1);
      dateSix.innerText =
        "П'ятниця, " + today.getDate() + "/" + today.getMonth();
      today.setDate(today.getDate() + 1);
      dateSeven.innerText =
        "Субота, " + today.getDate() + "/" + today.getMonth();

      break;
    case 1:
      dateTwo.innerText =
        "Понеділок, " + today.getDate() + "/" + today.getMonth();
      today.setDate(today.getDate() + 1);
      dateThree.innerText =
        "Вівторок, " + today.getDate() + "/" + today.getMonth();
      today.setDate(today.getDate() + 1);
      dateFour.innerText =
        "Середа, " + today.getDate() + "/" + today.getMonth();
      today.setDate(today.getDate() + 1);
      dateFive.innerText =
        "Четвер, " + today.getDate() + "/" + today.getMonth();
      today.setDate(today.getDate() + 1);
      dateSix.innerText =
        "П'ятниця, " + today.getDate() + "/" + today.getMonth();
      today.setDate(today.getDate() + 1);
      dateSeven.innerText =
        "Субота, " + today.getDate() + "/" + today.getMonth();
      today.setDate(today.getDate() + 1);
      dateFour.innerText =
        "Неділя, " + today.getDate() + "/" + today.getMonth();

      break;
    case 2:
      dateThree.innerText =
        "Вівторок, " + today.getDate() + "/" + today.getMonth();
      today.setDate(today.getDate() + 1);
      dateFour.innerText =
        "Середа, " + today.getDate() + "/" + today.getMonth();
      today.setDate(today.getDate() + 1);
      dateFive.innerText =
        "Четвер, " + today.getDate() + "/" + today.getMonth();
      today.setDate(today.getDate() + 1);
      dateSix.innerText =
        "П'ятниця, " + today.getDate() + "/" + today.getMonth();
      today.setDate(today.getDate() + 1);
      dateSeven.innerText =
        "Субота, " + today.getDate() + "/" + today.getMonth();
      today.setDate(today.getDate() + 1);
      dateFour.innerText =
        "Неділя, " + today.getDate() + "/" + today.getMonth();
      today.setDate(today.getDate() + 1);
      dateTwo.innerText =
        "Понеділок, " + today.getDate() + "/" + today.getMonth();

      break;
    case 3:
      dateFour.innerText =
        "Середа, " + today.getDate() + "/" + today.getMonth();
      today.setDate(today.getDate() + 1);
      dateFive.innerText =
        "Четвер, " + today.getDate() + "/" + today.getMonth();
      today.setDate(today.getDate() + 1);
      dateSix.innerText =
        "П'ятниця, " + today.getDate() + "/" + today.getMonth();
      today.setDate(today.getDate() + 1);
      dateSeven.innerText =
        "Субота, " + today.getDate() + "/" + today.getMonth();
      today.setDate(today.getDate() + 1);
      dateFour.innerText =
        "Неділя, " + today.getDate() + "/" + today.getMonth();
      today.setDate(today.getDate() + 1);
      dateTwo.innerText =
        "Понеділок, " + today.getDate() + "/" + today.getMonth();
      today.setDate(today.getDate() + 1);
      dateThree.innerText =
        "Вівторок, " + today.getDate() + "/" + today.getMonth();

      break;
    case 4:
      dateFive.innerText =
        "Четвер, " + today.getDate() + "/" + today.getMonth();
      today.setDate(today.getDate() + 1);
      dateSix.innerText =
        "П'ятниця, " + today.getDate() + "/" + today.getMonth();
      today.setDate(today.getDate() + 1);
      dateSeven.innerText =
        "Субота, " + today.getDate() + "/" + today.getMonth();
      dateOne.innerText = "Неділя, " + today.getDate() + "/" + today.getMonth();
      today.setDate(today.getDate() + 1);
      dateFour.innerText =
        "Неділя, " + today.getDate() + "/" + today.getMonth();
      today.setDate(today.getDate() + 1);
      dateTwo.innerText =
        "Понеділок, " + today.getDate() + "/" + today.getMonth();
      today.setDate(today.getDate() + 1);
      dateThree.innerText =
        "Вівторок, " + today.getDate() + "/" + today.getMonth();
      today.setDate(today.getDate() + 1);
      dateFour.innerText =
        "Середа, " + today.getDate() + "/" + today.getMonth();

      break;
    case 5:
      dateSix.innerText =
        "П'ятниця, " + today.getDate() + "/" + today.getMonth();
      today.setDate(today.getDate() + 1);
      dateSeven.innerText =
        "Субота, " + today.getDate() + "/" + today.getMonth();
      dateOne.innerText = "Неділя, " + today.getDate() + "/" + today.getMonth();
      today.setDate(today.getDate() + 1);
      dateFour.innerText =
        "Неділя, " + today.getDate() + "/" + today.getMonth();
      today.setDate(today.getDate() + 1);
      dateTwo.innerText =
        "Понеділок, " + today.getDate() + "/" + today.getMonth();
      today.setDate(today.getDate() + 1);
      dateThree.innerText =
        "Вівторок, " + today.getDate() + "/" + today.getMonth();
      today.setDate(today.getDate() + 1);
      dateFour.innerText =
        "Середа, " + today.getDate() + "/" + today.getMonth();
      today.setDate(today.getDate() + 1);
      dateFive.innerText =
        "Четвер, " + today.getDate() + "/" + today.getMonth();

      break;
    case 6:
      dateSeven.innerText =
        "Субота, " + today.getDate() + "/" + today.getMonth();
      today.setDate(today.getDate() + 1);
      dateOne.innerText = "Неділя, " + today.getDate() + "/" + today.getMonth();
      today.setDate(today.getDate() + 1);
      dateFour.innerText =
        "Неділя, " + today.getDate() + "/" + today.getMonth();
      today.setDate(today.getDate() + 1);
      dateTwo.innerText =
        "Понеділок, " + today.getDate() + "/" + today.getMonth();
      today.setDate(today.getDate() + 1);
      dateThree.innerText =
        "Вівторок, " + today.getDate() + "/" + today.getMonth();
      today.setDate(today.getDate() + 1);
      dateFour.innerText =
        "Середа, " + today.getDate() + "/" + today.getMonth();
      today.setDate(today.getDate() + 1);
      dateFive.innerText =
        "Четвер, " + today.getDate() + "/" + today.getMonth();
      today.setDate(today.getDate() + 1);
      dateSix.innerText =
        "П'ятниця, " + today.getDate() + "/" + today.getMonth();

      break;
  }
}
