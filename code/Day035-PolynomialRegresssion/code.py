import numpy as np
import pandas as pd

dataset = pd.read_csv('Data/Position_Salaries.csv')
X = dataset.iloc[:, 1].values
y = dataset.iloc[:, -1].values

from sklearn.model_selection import train_test_split
X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.2, random_state=0)

from sklearn.linear_model import LinearRegression
from sklearn.preprocessing import PolynomialFeatures

polynomial_regression = PolynomialFeatures(degree = 3)
X_polynomial = polynomial_regression(X)

regressor = LinearRegression()
regressor.fit(X_train)