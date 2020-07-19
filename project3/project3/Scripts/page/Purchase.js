var pp = document.getElementById("Modal_Change_Password_Success").getAttribute("data-value");
console.log(pp)
if (parseInt(pp) === 0) {
    $("#Modal_Change_Password_Success").modal("show");
}
var loadDataCart = () => {
    const cart = document.getElementById("bodyCart");
    let totalPrice = 0;
    if (cart !== null) {
        cart.innerHTML = '';
        axios.get(`${host}Home/GetCart`).then(result => {
            console.log(result)
            result.data.reverse().forEach(item => {
                totalPrice += item.TotalPrice;
                cart.innerHTML += `<tr id= "Cart${item.id}" data-totalPrice="${item.TotalPrice}">
                    <td> <img src="${host}${item.Img}" /></td>
                    <td>
                        <a href=${host}Product/Detail/${item.id_bou} >
                            ${item.Name}
                        </a>
                    </td>
                    <td>
                        <p>${item.Price}<span>đ</span></p>
                    </td>
                    <td>${item.amount}</td>
                    <td>
                        <p>${parseInt(item.Price) * parseInt(item.amount)}<span>đ</span></p>
                    </td>
                    <td><i class="fas fa-trash-alt" onclick="deleteCart(event,${item.id},afterDeleteCart(Cart${item.id}))"></i></td>
                </tr>`
            });
            document.getElementById("totalPrice").innerHTML = totalPrice;
        });
    }
}
loadDataCart();
function afterDeleteCart(id) {
    let item = parseInt(id.getAttribute("data-totalPrice"));
    let totalPrice = parseInt(document.getElementById("totalPrice").innerHTML);
    document.getElementById("totalPrice").innerHTML = totalPrice - item;
    id.remove();
}

