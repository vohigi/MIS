// const nav = document.getElementsByTagName("nav");
const nav = document.getElementById("navBar");
const navText = Array.from(document.getElementsByClassName("nav-text"));
const navIcons = Array.from(document.getElementsByClassName("fa-home"));
const navLinks = Array.from(document.getElementsByClassName("nav-link"));

nav.addEventListener("mouseover", function(e) {
  navText.forEach(element => {
    element.classList.add("nav-text-open");
  });
  nav.style.width = "15%";
});
nav.addEventListener("mouseout", function() {
  navText.forEach(element => {
    element.classList.remove("nav-text-open");
  });
  nav.style.width = "60px";
});
