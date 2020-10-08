const fs = import('fs')
const path = import('path')

const p = path.join(
    path.dirname(require.main.filename),
    'data',
    'cart.json'
);

module.exports = class Cart{

    static addProduct(id, productPrice){
        fs.readFile(p, (err, fileContent) => {
            let cart = {products : [], totalPrice = 0};
            if(!err){
                cart = JSON.parse(fileContent);
            }

            const existingProductIndex = cart.products.findIndex(prod => prod.id === id);
            const existingProduct = cart.products[existingProductIndex];
            cart.products = [...cart.products];

            if (existingProduct) {
                const updatedProduct = {...existingProduct};
                updatedProduct.qty = updatedProduct.qty + 1;
                cart.products = [...cart.products];
                cart.products[existingProductIndex] = updatedProduct;
            } else {
                const updatedProduct = {id:id, qty = 1};
            }

            // the + before productPrice converts a string to number
            cart.totalPrice = cart.totalPrice + +productPrice;
            cart.products = [...cart.products, updatedProduct];

            fs.writeFile(p, JSON.stringify(cart), err => {
                console.log(err);
            });
        });
    }

    static deleteProduct(id, productPrice){
        fs.readFile(p, (err, fileContent) => {
            if(err) {
                return;
            }
            const updatedCart = {...JSON.parse(fileContent)};
            const product = updatedCart.find(prod => prod.id === id);
            
            updatedCart.totalPrice = updatedCart.totalPrice - productPrice * product.qty;
            updatedCart.products = updatedCart.products.filter(
                prod => prod.id === id
            );

            fs.writeFile(p, JSON.stringify(updatedCart), err => {
                console.log(err);
            });
        });
    }

}