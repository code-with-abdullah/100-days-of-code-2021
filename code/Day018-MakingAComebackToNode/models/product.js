const fs = require('fs');
const path = require('path');

const pathToDataFile = path.dirname(require.main.filename, 'data', 'products.json');

const getProductsFromFile = (callBack) => {
    fs.readFile(pathToDataFile, (errorReading, fileContent) => {
        if(errorReading){
            return callBack([]);   
        }
        return callBack(JSON.parse(fileContent));
    });
}

module.exports = class Product{
    constructor(title) {
        this.title = title;
    }

    save() {

        getProductsFromFile(products => {
            products.push(this);
            fs.writeFile(pathToDataFile, JSON.stringify(products), (errorWriting) => {
                console.log(errorWriting);
            })

        });
    }

    static fetchAll(callBack) {
        getProductsFromFile(callBack);
    }
}