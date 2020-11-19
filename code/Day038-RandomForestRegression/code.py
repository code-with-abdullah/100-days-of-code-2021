import numpy as np
import pandas as pd

dataset = pd.read_csv('Data/Position_Salaries.csv')
X = dataset.iloc[:, 1].values
y = dataset.iloc[:, -1].values

from sklearn.ensemble import RandomForestRegressor
regressor = RandomForestRegressor(n_estimators=250, random_state=0)
regressor.fit(X, y)

predict_on = input('Enter the number of years of experience : ')
y_pred = regressor.predict(predict_on)
print("Predicted value is : ", y_pred)