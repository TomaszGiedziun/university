"""
	Zadanie programowania liniowego
"""
from scipy.optimize import linprog
c = [-11, -12]
A = [[3, 2], [4, 5]]
b = [12, 23]
# x0_bounds = (0, None)
# x1_bounds = (0, None)
res = linprog(c, A_ub=A, b_ub=b)
print(res)
