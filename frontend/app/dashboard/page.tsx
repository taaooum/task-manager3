import Overview from "@/components/Overview";
import Sidebar from "@/components/Sidebar";
import React from "react";

export default async function Page() {

  const data = await fetch('http://localhost:5046/api/Buckets')
  const buckets = await data.json()

  return (
    <>
      <Sidebar> 
        {buckets.map((bucket : Bucket) => (
          <li key={bucket.id} >
            {bucket.title}
          </li>
        ))}
      </Sidebar>
      <Overview />
    </>
  );
}
