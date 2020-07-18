document.getElementById("slideContent").style.backgroundImage = "url('https://localhost:44350/img/slide1.jpg')";

let count =0
setInterval(() => {
    if (count < 0) {
        count = 2;
    } else if (count > 2) {
        count = 0;
    }
    document.getElementById("slideContent").style.backgroundImage =`url('https://localhost:44350/img/slide${count +1}.jpg')`;
    const result = document.querySelectorAll(".slide>.container>.slide__content>.slide__item");
    result.forEach(item => {
        item.classList.remove("active");
    })
    result[count].classList.add('active');
    count++;

}, 3000);

window.onscroll = () => {
    if (document.body.scrollTop > 650 || document.documentElement.scrollTop > 650) {
        document.querySelector('.header').classList.add("active");
    } else {
        document.querySelector('.header').classList.remove("active");
    }
}
