"use client";
import React, { useState } from 'react';
import Image from 'next/image';
import { motion } from "framer-motion";
import Logo from '../../../public/images/Logo.png';
import { authService } from '@/services/authService';
import { useRouter } from "next/navigation";

const Login: React.FC = () => {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [loading, setLoading] = useState(false);
  const router = useRouter();

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setLoading(true);

    try {
      const response = await authService.login({ email, password });
      console.log(response.data)
      if (response.status === 200) {
        localStorage.setItem("user", JSON.stringify(response.data));
        router.push("/patient/appointments");
      } else {
        alert(`Erro: ${response.statusText}`);
      }
    } catch (err) {
      console.error(err);
    } finally {
      setLoading(false);
    }
  };


  return (
    <div className="bg-[url('/images/Login-bg.png')] bg-cover bg-center w-full h-screen flex justify-center items-start text-white">
      <main className=' w-[80%] flex '>
        <div className=' mt-[9.433rem] ml-[9.875rem]' >
          <motion.div
            initial={{ opacity: 0, x: 100 }}
            transition={{ duration: 0.5, delay: 0.55 }}
            whileInView={{ opacity: 1, x: 1 }}
            viewport={{ once: true }}
            className='flex items-center'>
            <figure className='w-[3.701rem] h-[3.684rem]'>
              <Image src={Logo} alt='MedSchedule Logo' />
            </figure>
            <h1 className="font-alexandria text-3xl font-semibold ml-[0.4rem]">MedSchedule</h1>
          </motion.div>
          <div className='mt-[13rem] '>
            <motion.h1
              initial={{ opacity: 0, x: -100 }}
              transition={{ duration: 0.5, delay: 0.55 }}
              whileInView={{ opacity: 1, x: 1 }}
              viewport={{ once: true }}
              className='text-[3.349rem] font-semibold leading-snug'>
              Login para acessar <br />
              suas consultas
            </motion.h1>
            <motion.h2
              initial={{ opacity: 0, x: -100 }}
              transition={{ duration: 0.5, delay: 0.55 }}
              whileInView={{ opacity: 1, x: 1 }}
              viewport={{ once: true }}
              className='text-[1.675rem] mt-[1.161rem] text-[#AFAFAF]'>
              Gerencie suas consultas com facilidade!
            </motion.h2>
          </div>
        </div>

        <motion.form
          initial={{ opacity: 0, y: -100 }}
          transition={{ duration: 0.5, delay: 0.55 }}
          whileInView={{ opacity: 1, y: 1 }}
          viewport={{ once: true }}
          className=' bg-white ml-[21.491rem] mt-[26.158rem] rounded-[1.34rem] flex flex-col px-[3.684rem] py-[5.28rem] '>
          <div className='w-[35.752rem]'>
            <label className='text-[#696969] font-semibold text-[1.2rem]'>
              Email
            </label>
            <input value={email} onChange={e => setEmail(e.target.value)} placeholder='nome@example.com' className='w-full rounded-[0.31375rem] outline-0 border-[0.08rem] border-[#D7D7D7] text-[#696969] text-[1.1rem] p-[1.2rem] mt-[0.6875rem] mb-[3.068rem]' />

            <label className='text-[#696969] font-semibold text-[1.2rem]'>
              Senha
            </label>
            <input value={password} onChange={e => setPassword(e.target.value)} placeholder='Sua senha' className='w-full rounded-[0.31375rem] outline-0 border-[0.08rem] border-[#D7D7D7] text-[#696969] text-[1.1rem] p-[1.2rem] mt-[0.6875rem]' type='password' />
          </div>
          <div className='mt-[4.324rem] flex justify-between items-center  w-[35.752rem]'>
            <p className='text-[#4E4E4E] text-[1.1rem] font-semibold '>
              Ainda não possui uma conta?
              <span className='ml-[0.5rem] font-bold'>Criar agora</span>
            </p>
            <button
              onClick={handleSubmit}
              disabled={loading}
              className="bg-[#1352F1] text-[1.2rem] font-semibold px-[4.672rem] py-[1rem] rounded-[0.41875rem] cursor-pointer flex items-center justify-center gap-2"
            >
              {loading ? (
                <div className="w-5 h-5 border-2 border-white border-t-transparent rounded-full p-2 animate-spin"></div>
              ) : (
                "Login"
              )}
            </button>

          </div>
        </motion.form>

      </main>
    </div>
  );
};

export default Login;
