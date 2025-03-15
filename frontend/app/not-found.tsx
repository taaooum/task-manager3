import Logo from "@/components/logo";

export default function NotFound() {
    return (
        <div className="container py-8">
            <Logo className="w-2/3 max-w-sm mb-6 md:mb-16" />
            <h1 className="text-6xl font-semibold leading-none tracking-tight mb-6">Keine Panik!</h1>
            <h2 className="text-3xl font-semibold leading-none tracking-tight">
                Aber diese Seite wurde nicht gefunden.
            </h2>
        </div>
    )
}
