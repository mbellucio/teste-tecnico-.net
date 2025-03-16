# DotNet FGV Selection | DotNet-API

## Tech Stack
![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)
![Swagger](https://img.shields.io/badge/-Swagger-%23Clojure?style=for-the-badge&logo=swagger&logoColor=white)
![Docker](https://img.shields.io/badge/docker-%230db7ed.svg?style=for-the-badge&logo=docker&logoColor=white)
![JWT](https://img.shields.io/badge/JWT-black?style=for-the-badge&logo=JSON%20web%20tokens)


## Information
Type: <code>WebApi</code> </br>
Architecture: <code>Repository Pattern</code> </br>
Framework: <code>.Net</code>

## Project Setup
You must have <b>Docker</b> installed. </br>
Navigate to the root of the application and run the command: <code>docker-compose up -d --build</code> </br>
After a few minutes the Application should be running. Visit [localhost:5000](http://localhost:5000) to acess the Swagger page. 

# Tech test

## 1 - What will be the console output? 
```cs
var lista = new List { 1, 2, 3, 4, 5 };
var resultado = lista.Where(x => x % 2 == 0).Select(x => x * 2);
Console.WriteLine(string.Join(', ', resultado));
```
<b>Answer</b>: <code>The even numbers are multiplied by 2, thus, 4, 8.</code> </br>

## 2 - If you run this query, what will happen?
```sql
SELECT * FROM Usuarios WHERE Nome LIKE '%_Silva%'
```
<b>answer</b>: <code>All "usuarios" that have the string "Silva" in "Nome" will be presented as results of this query. E.G. "Matheus Silva", "Carlos Silva" ...</code> </br>

## 3 - What will be the output and why? 
```cs
public class Exemplo
{
  public string Nome { get; set; }
  public Exemplo(string nome)
  {
  Nome = nome ?? "Sem Nome";
  }
}
var obj = new Exemplo(null);
Console.WriteLine(obj.Nome);
```
<b>answer</b>: <code>The output will be "Sem nome" as the constructor require a name, and judging by this line <code>Nome = nome ?? "Sem Nome";</code> the null-coalescing operator "??" is returning "Sem Nome" in case the "nome" provided is null.</code> </br>

## 4 - What is wrong and how to fix it? 
```cs
public async Task<List<Usuario>> BuscarUsuarios()
{
  using (var db = new MeuDbContext())
  {
    return db.Usuarios.ToListAsync();
  }
}

```
<b>answer</b>: <code>It's missing the "await" just after the return statement, as the function is asyncronous.</code> </br>
