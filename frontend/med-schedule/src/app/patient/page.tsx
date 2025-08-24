"use client"
import React, { useState } from 'react';
import NavBar from '@/components/layout/NavBar/NavBar';
import SideBar from '@/components/layout/SideBar/SideBar';
import AppointmentBtn from '@/components/ui/AppointmentBtn/AppointmentBtn';
import { RiCalendarScheduleLine } from "react-icons/ri";
import { AiOutlineSchedule } from "react-icons/ai";
import { motion } from "framer-motion";
import AppointmentModal from '@/components/ui/AppointmentModal/AppointmentModal';

const Patient: React.FC = () => {
  const [open, setOpen] = useState(false);
  const [isModalOpen, setIsModalOpen] = useState(false);

  return (
    <div>
      <NavBar />
      <div className='w-full h-[90vh] flex flex-row'>
        <SideBar />
        <div className=' w-full p-10 flex flex-col items-center'>
          <main className='w-[80%] bg-[#fdfdfd] rounded-xl border-[0.1rem] border-[#D7D7D7] text-white p-5'>
            <h1 className='text-[#041643] text-3xl'>Menu de acesso rápido</h1>
            <div className='flex flex-row mt-12 justify-center gap-[3rem]'>
              <AppointmentBtn icon={RiCalendarScheduleLine} label='Agendar consulta' onClick={() => setIsModalOpen(!isModalOpen)} />
              <AppointmentBtn icon={AiOutlineSchedule} label='Exibir agendamentos' onClick={() => setOpen(!open)} />
            </div>
          </main>
          {open ?
            <motion.div
              initial={{ opacity: 0, y: 100 }}
              transition={{ duration: 0.5, delay: 0.55 }}
              whileInView={{ opacity: 1, y: 1 }}
              viewport={{ once: true }}
              className='bg-[#fdfdfd] rounded-xl border-[0.1rem] border-[#D7D7D7] w-[80%] h-20 mt-5 p-5'>
              <h1 className='text-[#041643] text-3xl'>Meus agendamentos</h1>
              <div className='flex flex-row mt-12 justify-center gap-[3rem]'>

              </div>
            </motion.div> : null}
          <AppointmentModal
            isOpen={isModalOpen}
            onClose={() => setIsModalOpen(false)}
          />
        </div>
      </div>
    </div>
  );
}

export default Patient;