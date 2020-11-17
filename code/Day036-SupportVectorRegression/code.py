import numpy as np
import pandas as pd

dataset = pd.read_csv('Data/Position_Salaries.csv')
X = dataset.iloc[:, 1].values
y = dataset.iloc[:, -1].values

from sklearn.preprocessing import StandardScaler
sc_X = StandartScaler()
sc_y = StandartScaler()
X = sc_X.fit_transform(X)
y = sc_y.fit_transform(y)

from sklearn.svm import SVR
regressor = SVR(kernel = 'rbf')
regressor.fit(X, y)

predict_on = input('Enter the number of years of experience : ')
y_pred_scaled = regressor.predict(sc_X.transform(np.array([[predict_on]])))
y_pred = sc_Y.inverse_transform(y_pred_scaled)