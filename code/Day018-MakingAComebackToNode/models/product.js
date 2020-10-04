const fs = require('fs');
const path = require('path');

const pathToDataFile = path.dirname(require.main.filename, 'data', 'products.json');

module.exports = class Product{
    constructor(title) {
        this.title = title;
    }

    save() {
        products.push(this);

        fs.readFile(pathToDataFile, (errorReading, fileContent) => {
            let products = [];
            if(!errorReading) {
                products = JSON.parse(fileContent);
            }
            products.push(this);
            fs.writeFile(pathToDataFile, JSON.stringify(products), (errorWriting) => {
                console.log(errorWriting);
            })
        });
    }

    static fetchAll(callBack) {
        let products = [];

        fs.readFile(pathToDataFile, (errorReading, fileContent) => {
            if(!errorReading){
                callBack([]);
            }
            callBack(JSON.parse(fileContent));
        });
    }
}