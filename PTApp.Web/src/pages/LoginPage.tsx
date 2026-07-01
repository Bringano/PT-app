import { useState } from "react"
import { useNavigate } from "react-router-dom"

function LoginPage() {
    const [email, setEmail] = useState("")
    const [password, setPassword] = useState("")
    const [error, setError] = useState("")
    const navigate = useNavigate()

    const handleLogin = async () => {
        const response = await fetch("http://localhost:5116/api/auth/login", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({ email, password })
        })

        if (!response.ok) {
            setError("Fel email eller lösenord")
            return
        }

        const data = await response.json()
        localStorage.setItem("token", data.token)
        navigate("/dashboard")
    }

    return (
        <div className="min-h-screen bg-gray-900 flex items-center justify-center">
            <div className="bg-gray-800 p-8 rounded-lg w-full max-w-md">
                <h1 className="text-white text-2xl font-bold mb-6">Logga in</h1>
                <div className="mb-4">
                    <label className="text-gray-400 text-sm mb-1 block">Email</label>
                    <input
                        type="email"
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                        className="w-full bg-gray-700 text-white rounded p-3 outline-none"
                        placeholder="din@email.com"
                    />
                </div>
                <div className="mb-6">
                    <label className="text-gray-400 text-sm mb-1 block">Password</label>
                    <input
                        type="password"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                        className="w-full bg-gray-700 text-white rounded p-3 outline-none"
                        placeholder="••••••••"
                    />
                </div>
                <button
                    onClick={handleLogin}
                    className="w-full bg-blue-700 text-white py-3 rounded font-bold hover:bg-blue-800">
                    Logga in
                </button>
                {error && (
                    <p className="text-red-500 text-sm mt-3">{error}</p>
                )}

            </div>
        </div>
    )
}

export default LoginPage