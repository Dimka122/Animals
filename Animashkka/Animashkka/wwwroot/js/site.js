/ document.addEventListener('DOMContentLoaded', (e) => {
//     document.getElementById('main').style.backgroundColor = 'red';
// });
document.addEventListener('DOMContentLoaded', (e) => {

    document.addEventListener('DOMContentLoaded', () => {
        let urlApi = 'https://localhost:7147/Cart/GetCart';
        fetch(urlApi)
            .then((res) => {
                return res.json();
            })
            .then((data) => {
                let container = document.getElementById('container');
                for (const iterator of data) {
                    let cart = document.createElement('div');
                    cart.setAttribute('class', 'cart');
                    cart.setAttribute('id', `${iterator['base_ccy']}_${iterator['ccy']}`);
                    cart.innerText = `${iterator['base_ccy']}-${iterator['ccy']}: ${iterator['buy']} / ${iterator['sale']}`;
                    container.append(cart);
                }
                // console.log(data);
            })
            .catch((err) => {
                console.error("BAD API!");
            });
    });
});