const Sequelize = require('sequelize');
const Sequelize = require('sequelize');

const sequelize = require('../util/database');

const CartItem = Sequelize.define('cartItem', {
    id : {
        type: sequelize.INTEGER,
        autoIncrement: true, 
        allowNull: false,
        primaryKey: true
    },
    quantity: Sequelize.INTEGER
});

module.exports = CartItem;