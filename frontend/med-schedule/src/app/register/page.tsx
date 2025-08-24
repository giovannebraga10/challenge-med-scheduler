"use client"
import React, { useState } from 'react';
import Image from 'next/image';
import { motion } from "framer-motion";
import Logo from '../../../public/images/Logo.png';


const Register: React.FC = () => {
  const [selectedRole, setSelectedRole] = useState<"paciente" | "medico" | null>(null);
  const [selectedSpecialty, setSelectedSpecialty] = useState('');

  return (
    <>
      <div className="bg-[url('/images/Login-bg.png')] bg-cover bg-center w-full h-screen flex justify-center items-start text-white">
        <div className=' mt-[3.433rem] items-center' >
          <motion.div
            initial={{ opacity: 0, x: 100 }}
            transition={{ duration: 0.5, delay: 0.55 }}
            whileInView={{ opacity: 1, x: 1 }}
            viewport={{ once: true }}
            className='flex items-center'>
            <figure className='w-[3.701rem] h-[3.684rem]'>
              <Image src={Logo} alt='MedSchedule Logo' />
            </figure>
            <h1 className="font-alexandria text-3xl font-semibold ">MedSchedule</h1>
          </motion.div>

        </div>
        <main className=' w-[80%] flex justify-center '>
          <div className=' flex flex-col items-center'>
            <div className='mt-[5rem] '>
              <motion.h1
                initial={{ opacity: 0, x: -100 }}
                transition={{ duration: 0.5, delay: 0.55 }}
                whileInView={{ opacity: 1, x: 1 }}
                viewport={{ once: true }}
                className='text-[3.349rem] text-center font-semibold leading-snug'>
                Login para acessar <br />
                suas consultas
              </motion.h1>
            </div>
            <motion.form
              initial={{ opacity: 0, y: -100 }}
              transition={{ duration: 0.5, delay: 0.55 }}
              whileInView={{ opacity: 1, y: 1 }}
              viewport={{ once: true }}
              className="bg-white mt-[1.5rem] rounded-[1.34rem] flex flex-col px-[3.684rem] py-[3.28rem]"
            >
              <div className="w-[35.752rem]">
                <label className="text-[#696969] font-semibold text-[1.2rem]">
                  Nome completo
                </label>
                <input
                  placeholder="Seu Nome"
                  className="w-full rounded-[0.31375rem] outline-0 border-[0.08rem] border-[#D7D7D7] text-[#696969] text-[1.1rem] p-[1.2rem] mt-[0.6875rem] mb-[1.5rem]"
                />

                <label className="text-[#696969] font-semibold text-[1.2rem]">
                  Email
                </label>
                <input
                  placeholder="nome@example.com"
                  className="w-full rounded-[0.31375rem] outline-0 border-[0.08rem] border-[#D7D7D7] text-[#696969] text-[1.1rem] p-[1.2rem] mt-[0.6875rem] mb-[1.5rem] "
                />
                <label className="text-[#696969] font-semibold text-[1.2rem]">
                  Senha
                </label>
                <input
                  placeholder="Sua senha"
                  className="w-full rounded-[0.31375rem] outline-0 border-[0.08rem] border-[#D7D7D7] text-[#696969] text-[1.1rem] p-[1.2rem] mt-[0.6875rem] mb-[1.5rem]"
                  type="password"
                />
                <div className="mt-[1rem]">
                  <label className="text-[#696969] font-semibold text-[1.2rem] block mb-3">
                    Você é:
                  </label>
                  <div className="flex gap-2">
                    {["Paciente", "Medico"].map((role) => (
                      <button
                        key={role}
                        type="button"
                        onClick={() => setSelectedRole(role.toLowerCase() as "paciente" | "medico")}
                        className={`flex-1 py-2 rounded border text-sm font-semibold ${role.toLowerCase() === selectedRole
                          ? "bg-blue-600 text-white border-blue-600"
                          : "bg-white text-gray-700 border-gray-300"
                          }`}
                      >
                        {role}
                      </button>
                    ))}
                  </div>
                  <div className="mt-[1.5rem]">
                    {selectedRole === "medico" && (
                      <div>
                        <label className="block mb-2 font-semibold text-[#696969] text-[1.2rem]">
                          Especialidade
                        </label>
                        <select
                          className="w-full rounded border-[0.08rem] border-[#D7D7D7] p-[1.2rem] text-[#696969] text-[1.1rem] outline-none focus:ring-2 focus:ring-blue-500"
                          value={selectedSpecialty}
                          onChange={(e) => setSelectedSpecialty(e.target.value)}
                        >
                          <option value="">Selecione...</option>
                          <option value="cardiologia">Cardiologia</option>
                          <option value="dermatologia">Dermatologia</option>
                          <option value="pediatria">Pediatria</option>
                          <option value="ortopedia">Ortopedia</option>
                          <option value="neurologia">Neurologia</option>
                          {/* adicione outras especialidades aqui */}
                        </select>
                      </div>
                    )}
                  </div>

                </div>
              </div>

              <div className="mt-[3.324rem] flex justify-between items-center w-[35.752rem]">
                <p className="text-[#4E4E4E] text-[1.1rem] font-semibold">
                  Já possui uma conta?
                  <span className="ml-[0.5rem] font-bold cursor-pointer">Login</span>
                </p>
                <button className="bg-[#1352F1] text-[1.2rem] font-semibold px-[4.672rem] py-[1rem] rounded-[0.41875rem] cursor-pointer text-white">
                  Cadastrar
                </button>
              </div>
            </motion.form>

          </div>
        </main >
      </div >

    </>
  );
}

export default Register;