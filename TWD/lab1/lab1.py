"""
	Zadanie programowania liniowego
"""
from scipy.optimize import linprog
c = [1,2,3,3,2,2]
A = [[-1,0,0,-1,0,0],[0,-1,0,0,-1,0],[0,0,-1,0,0,-1],[1,1,1,0,0,0],[0,0,0,1,1,1]]
b = [-2,-3,-4,5,6]
res = linprog(c, A_ub=A, b_ub=b)
print(res)
