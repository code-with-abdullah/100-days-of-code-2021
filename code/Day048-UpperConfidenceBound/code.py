import numpy as np
import pandas as pd
import matplotlib.pyplot as plt
import math

dataset = pd.read_csv('Data/Ads_CTR_Optimisation.csv')

d = 10
N = 10000
number_of_selections = [0] * d
sum_of_rewards = [0] * d

ad=0
average_reward = 0

ads_selected=[]

for n in range(N):
    max_upper_bound=0
    upper_bound=0

    for i in range(d):
        if(number_of_selections[i]>0):
            average_reward = sum_of_rewards[i] / number_of_selections[i]
            delta_i = math.sqrt(3/2 * math.log(n+1) / number_of_selections[i])
            upper_bound = average_reward + delta_i
        else:
            upper_bound = 1e400

        if(max_upper_bound>upper_bound):
            max_upper_bound=upper_bound
            ad=i
    ads_selected.append(ad)
    number_of_selections[ad] = number_of_selections[ad] + 1
    reward = dataset.values[n, ad]
    sum_of_rewards[ad] = sum_of_rewards[ad] + 1

plt.hist(ads_selected)
plt.show()