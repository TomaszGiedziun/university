import random

class VerySecure:


	def __init__(self, key_file_name='key.txt', key_size=256,
						verbose=False):
		"""Very Secure 
		args:
			key_file - file with a key
			key_size - number of chacters in key
			verbose - display debugg messages
		"""
		self.key_file_name = key_file_name
		self.key_size = key_size
		self.verbose = verbose

	def d(self, message):#verbose true/false whether you want to see prints
		if self.verbose:
			print message

	def read_key(self): #read key and check for its validation
		with open(self.key_file_name, 'r') as f:
			self.lista  = [int(line.rstrip().split("-")[-1]) for line in f]# rstrip - right strip
		items = ['%s-%s' %(i,item) for i, item in enumerate(self.lista) if self.lista.count(item) > 1]
		if items:
			self.d('''Got a problem boss, Thoes keys: %s  are assigned to the same ones
			''' % (', '.join(items)))


	def generate_key(self): # generate random key parts
		with open(self.key_file_name, 'w') as f:
			self.lista = [i for i in range(self.key_size)]
			random.shuffle(self.lista)
			for i in range(self.key_size):
				f.write('%d-%d\n' % (i, self.lista[i]))

	def encrypt(self, in_file_name='in.txt', out_file_name='out.txt'):
		with open (in_file_name, 'r') as fi:
			with open (out_file_name, 'w') as fo:
				for line in fi:
					self.d('read input : %s' % line.rstrip())
					s = ''.join([chr(self.lista[ord(x)]) for x in line if ord(x) != 10])
					self.d('encrypted: %s' % s)
					fo.write("%s\n" % s)

	def decrypt(self, in_file_name='in.txt', out_file_name='out.txt'):
		with open (out_file_name, 'r') as fo:
			with open (in_file_name, 'r') as fi:
				for line in fo:
					s = ''.join([chr(self.lista.index(ord(x))) for x in line if ord(x) != 10])#output
					a = fi.readline().rstrip()#input
					if a == s:
						self.d('output: %s \t-> decrypted : %s ==  %s : input \n' % (line, s, a))




if __name__ == "__main__":
	vs = VerySecure(verbose=True)
	# vs.read_key()
	vs.generate_key()
	vs.encrypt()
	vs.decrypt()
