$(document).on("click", ".single-modal-btn", function (e) {
    e.preventDefault();

    let url = $(this).attr("href");

    fetch(url)
        .then(response => {

            if (response.ok) {
                return response.text()
            }
            else {
                alert("Xeta bas verdi!")
            }
        })
        .then(data => {
            $("#quickModal .modal-dialog").html(data)
            $("#quickModal").modal('show');
        })
   
})

const shopBtn = querySelector(".single-basket-button");
const carttotal = querySelector(".cart-total .text-number");

shopBtn.addEventListener("click",(e) => {
    e.preventDefault();
    alert("dsadas")
    let url = e.target.getAttribute("href");

    fetch(url)
        .then(response => {
            if (response.ok) {
                return response.json()
            }
            else {
                alert("xeta bas verdi!")
            }
        })
        .then(data => {
            let bookcount = JSON.parse(data);
            carttotal.innerHTML += bookcount;
            
        })
})

$(document).on("click", ".single-basket-button", function (e) {
    e.preventDefault();

    

})
