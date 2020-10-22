const Sequelize = require('sequelize');
const Sequelize = require('sequelize');

const sequelize = require('../util/database');

const Cart = Sequelize.define('cart', {
    id : {
        type: sequelize.INTEGER,
        autoIncrement: true, 
        allowNull: false,
        primaryKey: true
    }
});

module.exports = Cart;