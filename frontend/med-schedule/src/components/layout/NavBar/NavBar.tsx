import React from 'react';
import Image from 'next/image';
import Logo from '../../../../public/images/Logo.png'

const NavBar: React.FC = () => {
  return (
    <>
      <nav className=' text-[1.2rem] text-[#292a2c] border-b-[0.1rem] py-3 px-8 border-b-[#dadada]'>
        <ul className='flex flex-row items-center justify-between h-full'>
          <a href="#" className='flex flex-row items-center gap-2'>
            <figure>
              <Image src={Logo} alt='Logo' />
            </figure>
            <h1 className='font-semibold'>MedSchedule</h1>
          </a>
          <div className="flex flex-row h-full items-center">
            <div className='flex '>
              <li className='px-3 '>
                <a href='#' className='cursor-pointer font-semibold hover:text-[#1352F1]'>Agendamentos</a>
              </li>
              <li className='px-3 '>
                <a href='#' className='cursor-pointer font-semibold hover:text-[#1352F1]'>Agendar uma consulta</a>
              </li>
            </div>
            <div className='flex flex-col items-center font-semibold justify-center ml-5 px-7 h-full'>
              <a href='#'>Nome do usuário</a>
            </div>
          </div>
        </ul>
      </nav>
    </>
  );
}

export default NavBar;