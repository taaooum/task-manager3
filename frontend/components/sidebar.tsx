import { MoreVertical, ChevronLast, ChevronFirst } from "lucide-react"
import React from 'react'

import { ReactNode } from 'react';

const Sidebar = ({ children }: { children: ReactNode }) => {
  return (
    <aside className='h-screen w-100'>
        <nav className='h-full flex flex-col bg-gray-800 text-white'>
            <div className="border-t flex p-3">
                <img
                    src="https://ui-avatars.com/api/?background=c7d2fe&color=3730a3&bold=true"
                    alt=""
                    className="w-10 h-10 rounded-md"
                />
                <div className={`
                    flex justify-between items-center
                    overflow-hidden transition-all w-52 ml-3 
                    `}
                >
                    <div className="leading-4">
                        <h4 className="font-semibold">John Doe</h4>
                        <span className="text-xs text-gray-600">johndoe@gmail.com</span>
                    </div>
                    <ChevronFirst size={20} /> // later should mobile optimized
                </div>
            </div>

            <ul className="flex-1 px-3">
                {children}
            </ul>
        </nav>
    </aside>
  )
}

export default Sidebar
