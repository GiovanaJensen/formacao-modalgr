import pandas as pd
from datetime import datetime

df = pd.read_csv("colaboradores.txt", sep='|', names=['Nome Completo', 'E-mail', 'Data de Nascimento'])

df[['dia','mes','ano']] = df['Data de Nascimento'].str.split("/", expand=True)
df = df.drop(['dia','ano'], axis=1)

current_month = datetime.today().month
df_birthday = df.loc[df['mes'] == current_month]

df_birthday = df_birthday['Nome Completo']
df_birthday.to_csv("aniversariantes_do_mes.txt", encoding="latin-1", header=False, index=False)