document
  .querySelector("#doctor-msp-table-body")
  .addEventListener("submit", e => {
    e.preventDefault();
    e.target.firstElementChild.setAttribute("name", "AppointmentId");
    e.target.submit();
  });
