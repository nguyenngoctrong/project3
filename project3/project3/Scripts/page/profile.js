var cc = document.getElementById("Customer_Information").getAttribute("data-value");
console.log(cc);
if (parseInt(cc) === 1) {
    $("#Modal_Update_Success").modal("show");
}

var pp = document.getElementById("Modal_Change_Password_Success").getAttribute("data-value");
console.log(pp);
if (parseInt(pp) === 1) {
    $("#Modal_Change_Password_Success").modal("show");
}