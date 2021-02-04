const wrappers = document.querySelectorAll(".select__wrapper");
const arrowElem = "<div class='select__arrow'>Arrow</div>";
wrappers.forEach((wrapper, i) => {
    wrapper.addEventListener("click", (e) => {
        if (wrapper.classList.contains("active")) {
            wrapper.classList.remove("active");
            if (e.target.classList.contains("select__item")) {
                resetTitleOfSelect();
                wrapper.querySelector(".select__title").innerHTML =
                    e.target.value + arrowElem;
            }
        } else {
            wrapper.classList.add("active");
        }
    });
});


// Reset

function resetTitleOfSelect() {
    const selectTitles = document.querySelectorAll(".select__title");
    const namesOfTitle = ["Map", "Result", "K/A/D"];

    selectTitles.forEach((title, i) => {
        title.innerHTML = namesOfTitle[i] + arrowElem;
    });
}

const reset = document.querySelector(".select__reset");
const rows = document.querySelectorAll(".stats__row");
reset.addEventListener("click", () => {
    resetTitleOfSelect();
    wrappers.forEach(wrapper => {
        wrapper.classList.remove("active");
    });

    rows.forEach(row => {
        row.style.display = "block";
    });
});