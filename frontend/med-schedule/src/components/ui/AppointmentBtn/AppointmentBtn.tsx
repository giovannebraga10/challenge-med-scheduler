import React from 'react';
import { IconType } from "react-icons";

interface AppointmentBtnProps {
  icon: IconType;
  label: string;
  onClick?: () => void;
}

const AppointmentBtn: React.FC<AppointmentBtnProps> = ({ icon: Icon, label, onClick }) => {
  return (
    <>
      <button
        onClick={onClick}
        className="flex flex-col items-center bg-[#1352F1] gap-2 px-[12rem] py-[5rem]  text-white rounded-[1rem] transition hover:cursor-pointer">
        <Icon size={40} />
        <span className='text-2xl'>{label}</span>
      </button>
    </>
  );
}

export default AppointmentBtn;