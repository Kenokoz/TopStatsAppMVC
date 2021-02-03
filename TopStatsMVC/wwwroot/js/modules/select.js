const wrappers = document.querySelectorAll(".select__wrapper");
const arrowElem = "<div class='select__arrow'>Arrow</div>";
wrappers.forEach((wrapper, i) => {
    wrapper.addEventListener("click", (e) => {
        if (wrapper.classList.contains("active")) {
            wrapper.classList.remove("active");
            if (e.target.classList.contains("select__item")) {
                wrapper.querySelector(".select__title").innerHTML =
                    e.target.innerText + arrowElem;
            }
        } else {
            wrapper.classList.add("active");
        }
    });
});


// Reset

const reset = document.querySelector(".select__reset");
const selectTitles = document.querySelectorAll(".select__title");
reset.addEventListener("click", () => {
    const namesOfTitle = ["Map", "Result", "K/A/D"];
    const rows = document.querySelectorAll(".stats__row");

    selectTitles.forEach((title, i) => {
        title.innerHTML = namesOfTitle[i] + arrowElem;
    });
    wrappers.forEach(wrapper => {
        wrapper.classList.remove("active");
    });

    rows.forEach(row => {
        row.style.display = "block";
    });
});