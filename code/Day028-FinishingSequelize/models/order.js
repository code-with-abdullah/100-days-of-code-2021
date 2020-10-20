const Sequelize = require('sequelize');

const sequelize = require('../util/database');

const Order = Sequelize.define('order', {
    id:{
        type:Sequelize.INTEGER,
        autoIncrement: true,
        allowNull: false,
        primaryKey: true
    }
});

module.exports = Order;