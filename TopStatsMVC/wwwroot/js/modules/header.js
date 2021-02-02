const links = document.querySelectorAll(".nav__link");

links.forEach(link => {
    link.addEventListener("click", () => {
        link.classList.add("nav__active");
    });
});