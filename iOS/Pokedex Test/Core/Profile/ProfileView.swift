//
//  ProfileView.swift
//  Pokedex Test
//
//  Created by Martin on 22/11/23.
//

import SwiftUI

struct ProfileView: View {
    
    let user: User
    
    var body: some View {
        
        VStack {
            VStack {
                //username
                HStack {
                    Spacer()
                    Text(user.username)
                        .font(.custom("GILROY-BOLD", size: 28))
                    
                    Spacer()
                    Button {
                        AuthService.shared.logoutUser()
                    } label: {
                        Image(systemName: "rectangle.portrait.and.arrow.forward.fill")
                            .padding()
                            .background(Color.red)
                            .foregroundColor(.white)
                            .cornerRadius(24)
                    }
                    .padding(.trailing,13)
                    

                }
                //img
                Image(user.img ?? "pkebtn")
                    .resizable()
                    .scaledToFill()
                    .frame(width: 140, height: 140)
                    .clipShape(Circle())
                    .padding(.trailing, 16)
                //email
                Text("Email")
                    .font(.custom("GILROY-BOLD", size: 18))
                
                Text(user.email)
                    .font(.custom("GILROY-MEDIUM", size: 18))

                //RECORD?
            }
        }
        .padding(.bottom, 20)
        Spacer()
        
        if user.pokemonCollection == nil {
            Text("Add pokemon to your collection")
        } else {
            ScrollView{
                LazyVStack(spacing: 2) {
                    ForEach(user.pokemonCollection) { poke in
                        NavigationLink(destination:
                                        PokeInfoView(pokemon: poke, user: user)
                                       
                        ) {
                            PookemonConteinerView(poke: poke)
                        }
                    }
                }
            }
        }
        Spacer()
        
    }
}

#Preview {
    ProfileView(user: User.MOCK_USERS[2])
}
