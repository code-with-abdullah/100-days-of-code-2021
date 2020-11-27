import numpy as np
import pandas as pd

dataset = pd.read_csv('Data/Market_Basket_Optimisation.csv')
list_of_transactions = []

for i in range(7501):
    transactions.append([str(dataset.values[i, j]) for j in range(0, 20)])


from apyori import apriori
rules = apriori(transactions, min_support=0.005, min_confidence=0.2, min_lift=3, min_length=2)

results = list(rules)