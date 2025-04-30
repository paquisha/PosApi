import React, { useState, useEffect } from 'react';

import UserService from "../services/user.service";
import patient from '../types/pacient.type';

const Home: React.FC = () => {
  const [patient, setPatient] = useState<patient[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await UserService.getPublicContent();
        
        if (response.data.isSuccess && response.data) {
          setPatient(response.data.data);
        } else {
          setError(response.data.errorMessage || 'Error al cargar los datos');
        }
      } catch (err) {
        setError('Error de conexión');
      } finally {
        setLoading(false);
      }
    };

    fetchData();
  }, []);

  if (loading) return <div>Cargando...</div>;
  if (error) return <div>Error: {error}</div>;

  return (
    <div>
    <h2>Lista de Personas</h2>
    <ol>
      {patient.map((persona) => (
        <li key={persona.personaId}>
          <div>
            <strong>Nombre:</strong> {persona.firtsName} {persona.lastName}
          </div>
          <div>
            <strong>Email:</strong> {persona.email}
          </div>
          {persona.image && (
            <div>
              <img 
                src={persona.image} 
                alt={`${persona.firtsName} ${persona.lastName}`} 
                style={{ maxWidth: '100px' }}
              />
            </div>
          )}
        </li>
      ))}
    </ol>
  </div>
  );
};

export default Home;
