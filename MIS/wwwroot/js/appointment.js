document
  .querySelector("#app-time-choose-body")
  .addEventListener("submit", e => {
    e.preventDefault();
    e.target.firstElementChild.setAttribute("name", "AppointmentId");
    e.target.submit();
  });
