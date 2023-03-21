using Practica1.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

using System.Text;
using System.Threading.Tasks;

namespace Practica1.RepositoriuSql
{
    public class Sql 
    {
        //fields
        protected string connectionString;

      
        public Sql(string connectionString)
        {
            this.connectionString = connectionString;
        }

  
        public bool tryLogin(string username, string password)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Users WHERE username = '" + username + "' AND password = '" + password + "'";

                //initializam un tabel abstract, in care se vor salva userii cu username si password introdusi de noi
                SqlDataAdapter adapter = new SqlDataAdapter(command.CommandText, connection);
                DataTable data = new DataTable();
                adapter.Fill(data);

                if (data.Rows.Count == 1)
                    return true;
                else
                    return false;
            }


        }
        public IEnumerable<Abonat> getAbonat()
        {
            var abonatL = new List<Abonat>();

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Abonat ORDER BY ID_Abonat DESC";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var abonat = new Abonat();
                        abonat.ID_Abonat = Convert.ToInt32(reader[0]);
                        abonat.Nume = reader[1].ToString();
                        abonat.Adresa = reader[2].ToString();
                        abonat.IDNP = (int)reader[3];
                        abonat.TipClient = reader[4].ToString();
                        abonatL.Add(abonat);
                    }
                }
                connection.Close();
            }

            return abonatL;
        }

        public IEnumerable<Abonament> GetAbonament()
        {
            var abonamentL = new List<Abonament>();

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Abonament ORDER BY ID_Abonament DESC";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var abonament = new Abonament();
                        abonament.ID_Abonament = (int)reader[0];
                        abonament.Denumire = reader[1].ToString();
                        abonament.PretLunar = (int)reader[2];
                        abonamentL.Add(abonament);
                    }
                }
                connection.Close();
            }

            return abonamentL;
        }

        public IEnumerable<Apeluri> GetApeluri()
        {
            var apeluriL = new List<Apeluri>();

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Apeluri ORDER BY ID_Apel DESC";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var apeluri = new Apeluri();
                        apeluri.ID_Apel = (int)reader[0];
                        apeluri.ID_Abonat1 = (int)reader[1];
                        apeluri.ID_Abonat1 = (int)reader[2];
                        apeluri.Durata = (int)reader[3];
                        apeluri.DataApel = reader[4].ToString();
                        apeluriL.Add(apeluri);
                    }
                }
                connection.Close();
            }

            return apeluriL;
        }

        public IEnumerable<Cont> GetOreLucrate()
        {
            var ContL = new List<Cont>();

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Cont ORDER BY ID_Cont DESC";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var cont = new Cont();
                        cont.ID_Cont = (int)reader[0];
                        cont.Numar = reader[1].ToString();
                        cont.ID_Abonament = (int)reader[2];
                        cont.ID_Abonat = (int)reader[3];
                        cont.DataContractare = reader[4].ToString();
                        cont.Balansa = (int)reader[5];
                        cont.Locatie = reader[6].ToString();
                       
                        ContL.Add(cont);
                    }
                }
                connection.Close();
            }

            return ContL;
        }


        public IEnumerable<Optiuni> GetOptiuni()
        {
            var OptiuniL = new List<Optiuni>();

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Optiuni ORDER BY ID_Optiune DESC";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var optiuni = new Optiuni();
                        optiuni.ID_Optiune = (int)reader[0];
                        optiuni.Denumire = reader[1].ToString();
                        optiuni.Pret = (int)reader[2];
                        optiuni.Durata = (int)reader[3];
                        

                        OptiuniL.Add(optiuni);
                    }
                }
                connection.Close();
            }

            return OptiuniL;
        }
        public IEnumerable<Optiuni_Cont> GetOptiuni_Cont()
        {
            var Optiuni_ContL = new List<Optiuni_Cont>();

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Optiuni_Cont ORDER BY ID_OC DESC";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var optiuni_Cont = new Optiuni_Cont();
                        optiuni_Cont.ID_Optiune = (int)reader[1];
                        optiuni_Cont.ID_OC = (int)reader[0];
                        optiuni_Cont.ID_Cont = (int)reader[2];
                        optiuni_Cont.DataActivare = reader[3].ToString();



                        Optiuni_ContL.Add(optiuni_Cont);
                    }
                }
                connection.Close();
            }

            return Optiuni_ContL;
        }

      public void Add(Client client)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
                
            {

                int ID;
                int ID_C;
                
                connection.Open();
                command.Connection = connection;

                command.CommandText = "SELECT MAX(Abonat.ID_Abonat) FROM Abonat";
                ID = Convert.ToInt32(command.ExecuteScalar())+1;

                command.CommandText = "SELECT MAX(Cont.ID_Cont) FROM Cont";
                ID_C = Convert.ToInt32(command.ExecuteScalar())+1;
          
                command.Connection = connection;
                command.CommandText = "INSERT INTO Abonat VALUES (@ID_Abonat,@Nume,@Adresa,@IDNP,@TipCLinet)";
                command.Parameters.Add("ID_Abonat", SqlDbType.Int).Value =ID;
                command.Parameters.Add("Nume", SqlDbType.VarChar).Value = client.nume;
                command.Parameters.Add("Adresa", SqlDbType.VarChar).Value = client.adresa;
                command.Parameters.Add("IDNP", SqlDbType.NVarChar).Value = client.IDNP;
                command.Parameters.Add("TipCLinet", SqlDbType.VarChar).Value = client.tipClient+1;
            
                command.ExecuteNonQuery();

                command.CommandText = "INSERT INTO Cont VALUES (@ID_Cont,@Numar,@ID_Abonament,@ID_Abonat,@DataContractare,@Balansa,@Locatie)";
                command.Parameters.Add("ID_Cont", SqlDbType.Int).Value = ID_C;
                command.Parameters.Add("Numar", SqlDbType.NVarChar).Value = client.numar;
                command.Parameters.Add("ID_Abonament", SqlDbType.Int).Value = client.abanament+1;
                command.Parameters.Add("DataContractare", SqlDbType.Date).Value = DateTime.Now.ToString("MM/dd/yyyy");
                command.Parameters.Add("Balansa", SqlDbType.Money).Value =Convert.ToDouble(client.balansa);
               
                command.Parameters.Add("Locatie", SqlDbType.VarChar).Value = client.locatie;

                command.ExecuteNonQuery();

           

                connection.Close();
            }

        }
        
      public void Delete(string numar)
      {
          using (var connection = new SqlConnection(connectionString))
          using (var command = new SqlCommand())
          {
              connection.Open();
              command.Connection = connection;


                command.CommandText = "SELECT ID_Cont FROM CONT WHERE Numar =@numar";
                command.Parameters.Add("@numar", SqlDbType.NVarChar).Value = numar;
                int ID_Cont = Convert.ToInt32(command.ExecuteScalar());

                
                command.CommandText = "DELETE FROM Optiuni_Cont WHERE ID_Cont =@ID_Cont";
                command.Parameters.Add("@ID_Cont", SqlDbType.NVarChar).Value = ID_Cont;

                command.ExecuteNonQuery();

                //stergem angajatul din tabelul sau
                command.CommandText = "DELETE FROM Cont WHERE Numar = @numar";
              

                command.ExecuteNonQuery();

              connection.Close();
          }
      }


        public string SearchPhone(string nume)

        {
            string phone;
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;


                command.CommandText = "select Cont.Numar from Cont, Abonat Where Abonat.ID_Abonat = Cont.ID_Abonat and Abonat.Nume like @nume ";
                command.Parameters.Add("@nume", SqlDbType.NVarChar).Value = nume;
                phone = Convert.ToString(command.ExecuteScalar());

                return phone;
            }
        }
        public string ShowName(string numar)

        {
            string name;
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;

                command.CommandText = "select Abonat.Nume from Abonat, Cont Where Abonat.ID_Abonat = Cont.ID_Abonat and Cont.Numar = @numar ";
                command.Parameters.Add("@numar", SqlDbType.NVarChar).Value = numar;
                name = Convert.ToString(command.ExecuteScalar());
               
                return name;
            }
        }
        public string ShowAddress(string numar)

        {
            string address;
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;

                command.CommandText = "select Abonat.adresa from Abonat, Cont Where Abonat.ID_Abonat = Cont.ID_Abonat and Cont.Numar = @numar ";
                command.Parameters.Add("@numar", SqlDbType.NVarChar).Value = numar;
                address = Convert.ToString(command.ExecuteScalar());

                return address;
            }
        }
        public string ShowIDNP(string numar)

        {
            string IDNP;
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;

                command.CommandText = "select Abonat.IDNP from Abonat, Cont Where Abonat.ID_Abonat = Cont.ID_Abonat and Cont.Numar = @numar ";
                command.Parameters.Add("@numar", SqlDbType.NVarChar).Value = numar;
                IDNP = Convert.ToString(command.ExecuteScalar());

                return IDNP;
            }
        }
        public int SearchNrOfPhones(string an)

        {
            string year = "01/01/" + an;
            int nr;
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;

                command.CommandText = "SELECT COUNT(ID_Cont) FROM CONT WHERE Cont.DataContractare > @an";
                command.Parameters.Add("@an", SqlDbType.Date).Value = year;
                nr = Convert.ToInt32(command.ExecuteScalar());

                return nr;
            }
        }

    
        /*
              public IEnumerable<AngajatModel> GetAngajatiPensionari()
              {
                  var angajatiList = new List<AngajatModel>();

                  using (var connection = new SqlConnection(connectionString))
                  using (var command = new SqlCommand())
                  {
                      connection.Open();
                      command.Connection = connection;
                      command.CommandText = "SELECT * FROM Angajati WHERE(Angajati.Varsta >= 57 AND Angajati.Gen = 'F') OR(Angajati.Varsta >= 62 AND Angajati.Gen = 'M') ORDER BY Angajati.Varsta ASC";

                      using (var reader = command.ExecuteReader())
                      {
                          while (reader.Read())
                          {
                              var angajatModel = new AngajatModel();
                              angajatModel.AngajatID = (int)reader[0];
                              angajatModel.Nume = reader[1].ToString();
                              angajatModel.Anul_angajarii = (int)reader[2];
                              angajatModel.Data_nasterii = reader[3].ToString();
                              angajatModel.Salariu = Convert.ToDouble(reader[4]);
                              angajatModel.Gen = reader[5].ToString();
                              angajatModel.IdDepartament = (int)reader[6];
                              angajatModel.IdProfesie = (int)reader[7];
                              angajatModel.Varsta = (int)reader[8];
                              angajatModel.Stagiul = (int)reader[9];
                              angajatiList.Add(angajatModel);
                          }
                      }
                      connection.Close();
                  }

                  return angajatiList;
              }

              public string AvgSalariuBarbati(string departamentNume)
              {
                  string mediaSalariu = "0";

                  using (var connection = new SqlConnection(connectionString))
                  using (var command = new SqlCommand())
                  {
                      connection.Open();
                      command.Connection = connection;
                      command.CommandText = "SELECT AVG(Angajati.Salariu) FROM Angajati, Departamente WHERE Angajati.Gen = 'M' AND Departamente.nume = @departamentNume AND Angajati.idDepartament = Departamente.idDepartament;";
                      command.Parameters.Add("departamentNume", SqlDbType.VarChar).Value = departamentNume;

                      var result = command.ExecuteScalar();
                      mediaSalariu = result.ToString();

                      connection.Close();
                  }

                  return mediaSalariu;
              }

              public IEnumerable<AngajatModel> GetAngajatiFemeiStagiul()
              {
                  var angajatiList = new List<AngajatModel>();

                  using (var connection = new SqlConnection(connectionString))
                  using (var command = new SqlCommand())
                  {
                      connection.Open();
                      command.Connection = connection;
                      command.CommandText = "SELECT * FROM Angajati WHERE Angajati.Gen = 'F' AND Angajati.stagiul < 5 ORDER BY angajatID DESC";

                      using (var reader = command.ExecuteReader())
                      {
                          while (reader.Read())
                          {
                              var angajatModel = new AngajatModel();
                              angajatModel.AngajatID = (int)reader[0];
                              angajatModel.Nume = reader[1].ToString();
                              angajatModel.Anul_angajarii = (int)reader[2];
                              angajatModel.Data_nasterii = reader[3].ToString();
                              angajatModel.Salariu = Convert.ToDouble(reader[4]);
                              angajatModel.Gen = reader[5].ToString();
                              angajatModel.IdDepartament = (int)reader[6];
                              angajatModel.IdProfesie = (int)reader[7];
                              angajatModel.Varsta = (int)reader[8];
                              angajatModel.Stagiul = (int)reader[9];
                              angajatiList.Add(angajatModel);
                          }
                      }
                      connection.Close();
                  }

                  return angajatiList;
              }

              public int nrAngajati(int idProfesie)
              {
                  int nrAngajati = 0;

                  using (var connection = new SqlConnection(connectionString))
                  using (var command = new SqlCommand())
                  {
                      connection.Open();
                      command.Connection = connection;
                      command.CommandText = "SELECT COUNT(Angajati.AngajatID) FROM Angajati, Profesie WHERE Angajati.idProfesie = @idProf AND Angajati.idProfesie = Profesie.idProfesie";
                      command.Parameters.Add("idProf", SqlDbType.Int).Value = idProfesie;

                      nrAngajati = (int)command.ExecuteScalar();
                  }

                  return nrAngajati;
              }

              public IEnumerable<AngajatModel> GetAngajatiLunaX(int luna)
              {
                  var angajatiList = new List<AngajatModel>();

                  using (var connection = new SqlConnection(connectionString))
                  using (var command = new SqlCommand())
                  {
                      connection.Open();
                      command.Connection = connection;
                      command.CommandText = "SELECT * FROM Angajati WHERE MONTH(Angajati.Data_nasterii) = @luna";
                      command.Parameters.Add("luna", SqlDbType.Int).Value = luna;

                      using (var reader = command.ExecuteReader())
                      {
                          while (reader.Read())
                          {
                              var angajatModel = new AngajatModel();
                              angajatModel.AngajatID = (int)reader[0];
                              angajatModel.Nume = reader[1].ToString();
                              angajatModel.Anul_angajarii = (int)reader[2];
                              angajatModel.Data_nasterii = reader[3].ToString();
                              angajatModel.Salariu = Convert.ToDouble(reader[4]);
                              angajatModel.Gen = reader[5].ToString();
                              angajatModel.IdDepartament = (int)reader[6];
                              angajatModel.IdProfesie = (int)reader[7];
                              angajatModel.Varsta = (int)reader[8];
                              angajatModel.Stagiul = (int)reader[9];
                              angajatiList.Add(angajatModel);
                          }
                      }
                      connection.Close();
                  }

                  return angajatiList;
              }*/
    }
}
