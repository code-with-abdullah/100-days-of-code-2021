const fs = require('fs');
const path = require('path');

const cart = require('cart');

const p = path.join(
  path.dirname(require.main.filename),
  'data',
  'products.json'
);

const getProductsFromFile = cb => {
  fs.readFile(p, (err, fileContent) => {
    if (err) {
      cb([]);
    } else {
      cb(JSON.parse(fileContent));
    }
  });
};

module.exports = class Product {
  constructor(id, title, imageUrl, description, price) {
    this.id = id;
    this.title = title;
    this.imageUrl = imageUrl;
    this.description = description;
    this.price = price;
  }

  save() {
    
    getProductsFromFile(products => {

      if(this.id) {
        const existingProductIndex = Products.findIndex(prod => prod.id === this.id);
        const updatedProducts = [...Products];
        updatedProducts[existingProductIndex] = this;

        fs.writeFile(p, JSON.stringify(updatedProducts), err => {
          console.log(err);
        });
      } else {
        this.id = Math.random().toString();
        products.push(this);
        fs.writeFile(p, JSON.stringify(products), err => {
          console.log(err);
        });
      }
    });
  }

  static fetchAll(cb) {
    getProductsFromFile(cb);
  }

  static deleteById(id) {

    const product = products.find(prod => prod.id === id);

    getProductsFromFile(products =>{
      const updatedProducts = products.filter(prod => prod.id!==id);
      fs.writeFile(p, JSON.stringify(updatedProducts), err => {
        if(!err) {
          Cart.deleteById(id);
        }
      });
    });
  }

  static findById(id, cb){
    getProductsFromFile(products =>{
      const product = products.find(p => p.id===id);
      cb(product);
    });
  }
};
