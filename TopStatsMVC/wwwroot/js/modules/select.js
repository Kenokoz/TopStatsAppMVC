const arrowElem = "<div class='select__arrow'>Arrow</div>";

function showSelectItems(wrappersId) {
    wrappersId.forEach(id => {
        $(".stats__items").on("click", `#${id}`, function (e) {
            const wrapper = document.querySelector(`#${id}`);

            if (wrapper.classList.contains("active")) {
                wrapper.classList.remove("active");
                if (e.target.classList.contains("select__item")) {
                    resetTitleOfSelect();
                    wrapper.querySelector(".select__title").innerHTML =
                        e.target.value + arrowElem;
                }
            }
            else {
                wrapper.classList.add("active");
            }
        });
    });
}
showSelectItems(["select__wrapper-map", "select__wrapper-result", "select__wrapper-kda"]);



// Reset input
document.querySelector(".search__btn-stats").addEventListener("click", () => {
    setTimeout(() => {
        document.querySelector(".search-stats").reset();
    }, 40)
});


// Reset btn

function resetTitleOfSelect() {
    const selectTitles = document.querySelectorAll(".select__title");
    const namesOfTitle = ["Map", "Result", "K/A/D"];

    selectTitles.forEach((title, i) => {
        title.innerHTML = namesOfTitle[i] + arrowElem;
    });
}

$(".stats__items").on("click", ".select__reset", function () {
    resetTitleOfSelect();

    const reset = document.querySelector(".select__reset");
    const rows = document.querySelectorAll(".stats__row");
    const wrappers = document.querySelectorAll(".select__wrapper");

    wrappers.forEach(wrapper => {
        wrapper.classList.remove("active");
    });

    rows.forEach(row => {
        row.style.display = "block";
    });
});