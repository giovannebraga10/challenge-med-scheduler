import React from 'react';
import { AiOutlineHome } from "react-icons/ai";
import { GrSchedules } from "react-icons/gr";
import { AiOutlineSchedule } from "react-icons/ai";

const SideBar: React.FC = () => {
  return (
    <>
      <aside className='w-[15%] '>
        <nav className='mt-[5rem]'>
          <h2 className='px-6 text-[1.3rem] font-bold text-[#292a2c]'>Menu</h2>
          <ul className='flex flex-col gap-2 mt-5'>
            <li className='p-5 flex items-center gap-2 text-[1.2rem]  text-[#292a2c]  hover:text-[#1352F1]'>
              <AiOutlineHome size={20} color='#3b4358' />
              <a href='#'>Home</a>
            </li>
            <li className='p-5 flex items-center gap-2 text-[1.2rem]  text-[#292a2c] hover:text-[#1352F1] '>
              <AiOutlineSchedule size={20} color='#3b4358' />
              <a href='#'>Meus agendamentos</a>
            </li>
            <li className='p-5 flex items-center gap-2 text-[1.2rem]  text-[#292a2c] hover:text-[#1352F1] '>
              <GrSchedules size={20} color='#3b4358' />
              <a href='#'>Agendar Consulta</a>
            </li>
          </ul>
        </nav>
      </aside>
    </>
  );
}

export default SideBar;