const host = "https://localhost:44350/";
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
});



const loadCart = () => {
    let count = 0;
    const cart = document.getElementById("ListCart");
    const amount = document.getElementById("AmountCart");
    if (cart !== null) {
        cart.innerHTML = '';
        axios.get(`${host}Home/GetCart`).then(result => {
            result.data.reverse().forEach(item => {
                count += item.amount;
                cart.innerHTML += `<div class="cart__item">
                                <div class="cart__item-img"><img src="${host}${item.Img}" alt="" /></div>
                                <p>${item.Name}</p >
                                <div class="cart__item-info">
                                    <p class="cart__item-price">
                                        <i class="fas fa-dollar-sign"></i><span>${parseInt(item.amount) > 1 ? (item.Price + " X " + item.amount) : item.Price}</span><span></span>
                                    </p>
                                    <button onclick="deleteCart(event,${item.id})" >Delete</button>
                                </div>
                            </div>`
            })
            amount.innerHTML = count;
        });
    }
}

function main() {
    loadCart();
    var x = document.cookie;
    console.log(document.cookie.length);
}
main();
function addToCart(e,id_bou, amount) {
    e = e || window.event;
    e.preventDefault();
    checkLogin(() => {
        axios.post(`${host}Home/AddToCart?id_bou=${id_bou}&amount=${amount}`).then(function () {
            loadCart();
        }).catch(error => {
            console.log(error)
        })
    })

}
function deleteCart(e, id) {
    e = e || window.event;
    e.preventDefault();
    axios.post(`${host}Home/DeleteCart?id=${id}`).then(function (result) {
        loadCart();
    }).catch(error => {
        console.log(error)
    })

}

function checkLogin( doSomeThing ) {
    axios.post(`${host}Home/CheckLogin`).then(function (result) {
        console.log(result);
            if (result.data.check) {
                doSomeThing();
            } else {
                document.getElementById("loginModalCheck").click();

            }
        })
}