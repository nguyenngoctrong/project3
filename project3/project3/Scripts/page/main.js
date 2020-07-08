document.addEventListener('DOMContentLoaded', function (event) {
    const toggleNav = document.getElementById('toggleMenu');
    toggleNav.addEventListener('click', () => {
        toggleNav.classList.toggle("active");
        document.querySelector(".header>.container>.nav").classList.toggle('active');
    });
    const toggleNavItem = document.querySelectorAll(".nav>.nav__box>.nav__item>.nav__item-box");
    toggleNavItem.forEach(item => {
        item.addEventListener("click", function () {
            this.classList.toggle("active");

        })
    })
})