import numpy as np
import pandas as pd

dataset = pd.read_csv('Data/mall.csv')
X = dataset.iloc[:, [3, 4]].values


from sklearn.cluster import KMeans
k_means = KMeans(n_clusters=5, init='k-means++', max_iter=300, n_init=10, random_state = 0)

y_pred = k_means.fit_predict(X)

print(y_pred)